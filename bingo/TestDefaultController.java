public class TestDefaultController
{
    private class SampleRequest implements Request
    {
     public String getName()
     {
        return  "Test";
     }
    }
   private class SampleHandler implements RequestHandler
   {
   public Response process(Request request) throws Exception
   {
      return  new SampleResponse();
   }
   }
   private class SampleResponse implements Response
   {
   //empty
   }
   






}
