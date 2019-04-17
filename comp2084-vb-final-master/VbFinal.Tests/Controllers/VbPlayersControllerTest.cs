using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VbFinal.Controllers;
using VbFinal.Models;

namespace VbFinal.Tests.Controllers
{
    [TestClass]
    public class VbPlayersControllerTest
    {
        VbPlayersController controller;
        Mock<IMockVbPlayer> mock;
        List<VbPlayer> vbPlayers;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockVbPlayer>();

            vbPlayers = new List<VbPlayer>
            {
                new VbPlayer
                {
                    VbPlayerId = 961,
                    FirstName = "Lori",
                    Lastname = "S",
                    Photo = "https://img.icons8.com/color/384/beach-volleyball.png"
                },
                new VbPlayer
                {
                    VbPlayerId = 961,
                    FirstName = "Zak",
                    Lastname = "N",
                    Photo = "https://img.icons8.com/ultraviolet/384/beach-volleyball.png"
                }
            };

            mock.Setup(m => m.VbPlayers).Returns(vbPlayers.AsQueryable());
            controller = new VbPlayersController(mock.Object);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            // arrange
            // now handled in TestInitialize

            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexValidLoadsVbPlayers()
        {
            // act
            // call the index method
            // access the data model returned to the view
            // cast the data as a list of type Category
            var results = (List<VbPlayer>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(vbPlayers.OrderBy(c => c.FirstName).ToList(), results);

        }


        [TestMethod]
        public void EditLoadsValidId()
        {
            //act 

            var results = (List<VbPlayer>)((ViewResult)controller.Edit(1)).Model;

            // assert
            CollectionAssert.AreEqual(vbPlayers, results);


        }
        public void EditLoadsVbPlayerValidId()
        {
            //act 


            //assert


        }

        public void EditInvalidId()
        {
            //act 

            var results = (List<VbPlayer>)((ViewResult)controller.Edit(1)).Model;

            // assert
            CollectionAssert.AreEqual(vbPlayers, results);
            


        }

        public void EditNoId()
        {
            //act 


            //assert


        }


        public void EditSaveInvalid()
        {
            //act 


            //assert


        }

        public void EditSaveValid()
        {
            //act 


            //assert



        }




    }
}
