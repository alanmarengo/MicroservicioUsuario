using Aplication.Services;
using Data;
using Data.COMANDS;
using Domain.DTOS;
using Domain.QUERYS;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TEST_USUARIO
{
    public class AuthTest : baseTEST_AUTH
    {
        Context _db;
        GenericsRepository _genericsRepository;
        Mock<IAuthenticationQuery> _query;
        AuthenticacionService _authService;

        [SetUp]
        public void Setup()
        {
            _db = ConstruirContexto();
            _genericsRepository = new GenericsRepository(_db);
            _query = new Mock<IAuthenticationQuery>();
            _authService = new AuthenticacionService(_query.Object);

            ClienteCarritoDTOs dto = new ClienteCarritoDTOs
            {
                CarritoId = 1,
                ClienteId = 1,
                RolId = 1
            };
            _query.Setup(a => a.getCarrito("1")).Returns(async () => await Task.FromResult(dto));


            _query.Setup(a => a.getCarritoAdmin("1")).Returns(Task.FromResult(dto));



        }

        [Test]
        public void getCarritoExist()
        {
            var shoppingCart = _authService.getCarrito("1");
            Assert.IsNotNull(shoppingCart.Result);
        }

        [Test]
        public void getCarritoNotExist()
        {
            var shoppingCart = _authService.getCarrito("2");
            Assert.IsNull(shoppingCart.Result);
        }

        [Test]
        public void getCarritoAdminExist()
        {
            var shoppingCart = _authService.getCarritoAdmin("1");
            Assert.IsNotNull(shoppingCart.Result);
        }

        [Test]
        public void getCarritoAdminNotExist()
        {
            var shoppingCart = _authService.getCarritoAdmin("2");
            Assert.IsNull(shoppingCart.Result);
        }
    }
}
