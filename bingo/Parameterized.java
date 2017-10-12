@RunWith(value=Parameterized.class)
public class ParameterizedTest{
   private double expected;
   private double valueOne;
   privater double valueTwo;
   
   @Parameters 
   public static Collection<Integer[]> getTestParameters(){
    return Arrays.asList(new Integer[][]{
     (2,1,1),
     (3,2,1),
     (4,3,1),
    }};
    }

    public ParameterizedTest (double expected,double valueOne,double valueTwo) {
      this.expected = expected;
      this.valueOne = valueOne;
      this .valueTwo = valueTwo;
    }

    @Test 
    public void sum(){
        Calculator calc = new Calculator();
        assertEquals(expected,calc.add(valueOne,valueTwo),0);
    }
   }