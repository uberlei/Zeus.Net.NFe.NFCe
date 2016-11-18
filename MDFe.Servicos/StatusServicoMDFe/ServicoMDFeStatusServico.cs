﻿/********************************************************************************/
/* Projeto: Biblioteca ZeusMDFe                                                 */
/* Biblioteca C# para emissão de Manifesto Eletrônico Fiscal de Documentos      */
/* (https://mdfe-portal.sefaz.rs.gov.br/                                        */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2014 Adenilton Batista da Silva             */
/*                                       Zeusdev Tecnologia LTDA ME             */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe               */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/* Zeusdev Tecnologia LTDA ME - adenilton@zeusautomacao.com.br                  */
/* http://www.zeusautomacao.com.br/                                             */
/* Rua Comendador Francisco josé da Cunha, 111 - Itabaiana - SE - 49500-000     */
/********************************************************************************/
using System.Xml;
using DFe.Classes.Extencoes;
using DFe.Utils;
using ManifestoDocumentoFiscalEletronico.Classes.Informacoes.StatusServico;
using ManifestoDocumentoFiscalEletronico.Classes.Retorno.MDFeStatusServico;
using MDFe.Servicos.Enderecos.Helper;
using MDFe.Utils.Configuracoes;
using MDFe.Utils.Extencoes;
using MDFe.Utils.Validacao;
using MDFe.Wsdl.Gerado.MDFeStatusServico;

namespace MDFe.Servicos.StatusServicoMDFe
{
    public class ServicoMDFeStatusServico
    {
        public MDFeRetConsStatServ MDFeStatusServico()
        {
            var url = UrlHelper.ObterUrlServico(MDFeConfiguracao.VersaoWebService.TipoAmbiente).MDFeStatusServico;
            var codigoEstado = MDFeConfiguracao.VersaoWebService.UfDestino.GetCodigoIbgeEmString();
            var versao = MDFeConfiguracao.VersaoWebService.VersaoMDFeStatusServico.GetVersaoString();
            var certificadoDigital = MDFeConfiguracao.X509Certificate2;

            var ws = new MDFeStatusServico(url, codigoEstado, versao, certificadoDigital, MDFeConfiguracao.VersaoWebService.TimeOut);

            var consStatServMDFe = new MDFeConsStatServMDFe
            {
                TpAmb = MDFeConfiguracao.VersaoWebService.TipoAmbiente,
                Versao = MDFeConfiguracao.VersaoWebService.VersaoMDFeStatusServico,
                XServ = "STATUS"
            };

            // converte o objeto para uma string de xml
            var xmlEnvio = FuncoesXml.ClasseParaXmlString(consStatServMDFe);

            Validador.Valida(xmlEnvio, "consStatServMDFe_v1.00.xsd");

            var dadosRecibo = new XmlDocument();
            dadosRecibo.LoadXml(xmlEnvio);

            SalvarArquivoXml(consStatServMDFe);

            var retornoXml = ws.mdfeStatusServicoMDF(dadosRecibo);

            var retorno = FuncoesXml.XmlStringParaClasse<MDFeRetConsStatServ>(retornoXml.OuterXml);

            SalvarArquivoXmlRetorno(retorno);

            return retorno;

        }

        private void SalvarArquivoXmlRetorno(MDFeRetConsStatServ retorno)
        {
            if (MDFeConfiguracao.NaoSalvarXml()) return;

            var caminhoXml = MDFeConfiguracao.CaminhoSalvarXml;

            var arquivoSalvar = caminhoXml + @"\-retorno-status-servico.xml";

            FuncoesXml.ClasseParaArquivoXml(retorno, arquivoSalvar);
        }

        private void SalvarArquivoXml(MDFeConsStatServMDFe consReciMdfe)
        {
            if (MDFeConfiguracao.NaoSalvarXml()) return;

            var caminhoXml = MDFeConfiguracao.CaminhoSalvarXml;

            var arquivoSalvar = caminhoXml + @"\-resultado-status-servico.xml";

            FuncoesXml.ClasseParaArquivoXml(consReciMdfe, arquivoSalvar);
        }
    }
}