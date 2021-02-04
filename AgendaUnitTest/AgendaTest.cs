using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Agenda;

namespace AgendaUnitTest
{
    [TestClass]
    public class AgendaTest
    {
        Agenda1 agenda = new Agenda1();

        [TestMethod]
        public void TestAdd()
        {
            Contacto contacto = new Contacto("nombre", 987456321, "nombre@gmail.com");

            agenda.add(contacto);

            Assert.IsTrue(1== agenda.size());

        }
    }
}
