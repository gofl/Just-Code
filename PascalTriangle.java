
public class PascalTriangle {

	public static int binomialCoefficient(int n, int k){
		return (factorial(n) / (factorial(k) * factorial(n - k)));
	}
	
    public static int factorial(int n){
        if (n == 0) 
        	return 1;
        
        return n * factorial(n-1);
    }
    
    public static String printHelper(int n){
    	if(n == 0)
    		return "\t";
    	
    	return "\t" + printHelper(n - 1);
    }
    
    public static void print(int n){
    	for(int i = 0; i < n; i++){
    		System.out.print(printHelper((n - i)));    		
    		
    		for(int j = 0; j <= i; j++){
    			System.out.printf("%s \t\t", binomialCoefficient(i, j));
    		}    		
    		System.out.print("\n");
    	}
    }
	
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		print(10);
	}	
}
