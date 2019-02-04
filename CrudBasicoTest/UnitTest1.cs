using System;
using Xunit;
using CrudBasicoNETCoreMVC.Models;

namespace CrudBasicoTest
{
    public class UnitTest
    {
        [Fact]
        public void TestCaminhao()
        {            
            int IdModelo = 0;
            string DescricaoModelo = "modelo1";

            Modelo modelo = new Modelo{Id = IdModelo, Descricao = DescricaoModelo };

            Assert.NotNull(modelo);
            Assert.True(modelo.Id == IdModelo);
            Assert.True(modelo.Descricao == DescricaoModelo);

            int IdCaminhao = 0;
            string DescricaoCaminhao = "caminhao1";

            Caminhao caminhao = new Caminhao { Id = IdCaminhao, Nome = DescricaoCaminhao, ModeloId = 1, Modelo = modelo };
         
            Assert.NotNull(caminhao);
            Assert.True(caminhao.Id == IdCaminhao);
            Assert.True(caminhao.Nome == DescricaoCaminhao);
        }
    }
}
