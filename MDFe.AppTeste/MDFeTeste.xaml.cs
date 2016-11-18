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
using System.Windows;

namespace MDFe.AppTeste
{
    public partial class MDFeTeste
    {
        private readonly MDFeTesteModel _model;

        public MDFeTeste()
        {
            _model = new MDFeTesteModel();
            InitializeComponent();
            DataContext = _model;
        }

        private void Enviar1_0_Click(object sender, RoutedEventArgs e)
        {
            _model.CriarEnviar100();
        }

        private void ArquivoCertificado_Click(object sender, RoutedEventArgs e)
        {
            _model.ObterCertificadoArquivo();
        }

        private void Certificado_Click(object sender, RoutedEventArgs e)
        {
            _model.ObterSerialCertificado();
        }

        private void SalvarConfiguracoesXml_Click(object sender, RoutedEventArgs e)
        {
            _model.SalvarConfiguracoesXml();
        }

        private void MDFeTeste_OnLoaded(object sender, RoutedEventArgs e)
        {
            _model.CarregarConfiguracoesMDFe();
        }

        private void BuscarDiretorioSchema_Click(object sender, RoutedEventArgs e)
        {
            _model.BuscarDiretorioSchema();
        }

        private void GerarESalvar1_0_Click(object sender, RoutedEventArgs e)
        {
            _model.GerarESalvar1_0();
        }

        private void BuscarDiretorioSalvarXml_Click(object sender, RoutedEventArgs e)
        {
            _model.BuscarDiretorioSalvarXml();
        }

        private void ConsultaPorRecibo_Click(object sender, RoutedEventArgs e)
        {
            _model.ConsultaPorRecibo1_0();
        }

        private void ConsultaPorProtocolo_Click(object sender, RoutedEventArgs e)
        {
            _model.ConsultaPorProtocolo1_0();
        }

        private void ConsultaStatus_Click(object sender, RoutedEventArgs e)
        {
            _model.ConsultaStatusServico1_0();
        }

        private void ConsultaNaoEncerrados1_0_Click(object sender, RoutedEventArgs e)
        {
            _model.ConsultaNaoEncerrados1_0();
        }

        private void EventoIncluirCondutor_Click(object sender, RoutedEventArgs e)
        {
            _model.EventoIncluirCondutor1_0();
        }

        private void EventoEncerrarMDFe1_0_Click(object sender, RoutedEventArgs e)
        {
            _model.EventoEncerramento1_0();
        }

        private void EventoCancelarMDFe1_0_Click(object sender, RoutedEventArgs e)
        {
            _model.EventoCancelar1_0();
        }
    }
}
