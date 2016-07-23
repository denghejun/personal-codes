using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using UniversalBizCommand._01_Core;

namespace UniversalBizCommand
{
    public class MockedNoRequestNoResponseCommand : Command
    {
        protected override void BeforeRun()
        {
            throw new Exception("error");
        }

        protected override void Execute()
        {
            try
            {
                //var xmlA = new Model() { ID = 999, Name = "d" }.SerializeToXmlWithoutNamespaceWithoutEncoding();
                //string xmlB = "<Model ><ID>999</ID></Model>";
                //var jsonstring = ServiceStack.Text.JsonSerializer.SerializeToString(new Model() { Date = DateTime.Now, ID = 123 });
                //var mB = SerializeHelper.DeserializeFromXml<Model>(xmlB);
                //var mA = SerializeHelper.DeserializeFromXml<Model>(xmlA);
            }
            catch (Exception e)
            {

            }
        }

        protected override void WhenError(CommandException e)
        {
            //e.Handled = true;
        }
    }

    public class MockedOnlyRequestCommand : Command<MockedCommandRequest>
    {
        protected override void Execute(MockedCommandRequest request)
        {
            throw new Exception("Error");
        }

        protected override void WhenError(CommandException<MockedCommandRequest> e)
        {
            e.Handled = false;
        }
    }

    public class MockedOnlyResponseCommand : Command<MockedCommandResponse>
    {
        protected override MockedCommandResponse Execute()
        {
            throw new Exception("Error");
        }

        protected override void WhenError(CommandException<MockedCommandResponse> e, out MockedCommandResponse responseWhenErrorHandled)
        {
            e.Handled = true;
            responseWhenErrorHandled = new MockedCommandResponse() { id = 1000 };
        }
    }

    public class MockedHasRequestHasResponseCommand : Command<MockedCommandRequest, MockedCommandResponse>
    {
        protected override void BeforeRun(MockedCommandRequest request)
        {
            base.BeforeRun(request);
        }

        protected override void AfterRun(MockedCommandRequest request)
        {
            base.AfterRun(request);
        }

        protected override void AroundRun(MockedCommandRequest request)
        {
            base.AroundRun(request);
        }

        protected override bool CanExecute(MockedCommandRequest request, out MockedCommandResponse responseWhenCanExcuteFalse)
        {
            throw new Exception("123");
            return base.CanExecute(request, out responseWhenCanExcuteFalse);
        }

        protected override MockedCommandResponse InnerRun(MockedCommandRequest request)
        {
            return base.InnerRun(request);
        }

        protected override MockedCommandResponse Execute(MockedCommandRequest request)
        {
            return new MockedCommandResponse()
            {
                id = int.MaxValue
            };
        }

        protected override void WhenError(CommandException<MockedCommandRequest, MockedCommandResponse> e, out MockedCommandResponse responseWhenErrorHandled)
        {
            e.Handled = true;
            responseWhenErrorHandled = new MockedCommandResponse()
            {
                id = e.Request.id + 1000
            };
        }
    }

    public class OverrideInnerRunMethodCommand : Command<MockedCommandRequest, MockedCommandResponse>
    {
        protected override bool CanExecute(MockedCommandRequest request, out MockedCommandResponse responseWhenCanExcuteFalse)
        {
            return base.CanExecute(request, out responseWhenCanExcuteFalse);
        }

        protected override MockedCommandResponse InnerRun(MockedCommandRequest request)
        {
            return this.Execute(request);
        }

        protected override MockedCommandResponse Execute(MockedCommandRequest request)
        {
            return new MockedCommandResponse();
        }
    }

    public class MockedCommandRequest
    {
        public static MockedCommandRequest Empty { get { return new MockedCommandRequest(); } }
        public int id { get; set; }
    }

    public class MockedCommandResponse
    {
        public static MockedCommandResponse Empty { get { return new MockedCommandResponse(); } }
        public int id { get; set; }
    }


    [XmlRoot("Model")]
    public class Model
    {
        [XmlAttribute]
        public string Name
        {
            get;
            set;
        }

        [XmlIgnore]
        public DateTime? Date { get; set; }


        [XmlAttribute("Date")]
        [IgnoreDataMember]
        public DateTime DateS
        {
            get
            {

                return this.Date.Value;
            }
            set
            {

                this.Date = value;
            }
        }


        public bool ShouldSerializeDateS()
        {
            return Date.HasValue;
        }

        public int ID { get; set; }
        public List<string> MyProperty { get; set; }
    }
}
