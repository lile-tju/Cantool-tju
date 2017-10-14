  import static org.junit.Assert.*;
public class TestDefaultController
{
  @Test
   public class TestDefaultController
   {
      Request request = new SampleRequest();
      RequestHandler handler = new SampleHandler();
      controller.addHandler(request,handler);
      RequestHandler handler2 = controller.getHandler(request);
      assertSame("Handler we set in controller should be the same handler we get",handler2,handler);

  }

}
