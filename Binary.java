public class Binary {

	/*
	 * Add and subtract binary numbers 
	 */
	
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		System.out.println(Binary.add("0110", "0101"));
		System.out.println(Binary.substract("0110", "0101"));
	}
	
	public static String substract(String a, String b){
		if(a == null || b == null)
			return "";
		
		if(a.length() != b.length())
			return "";
		
		b = Binary.invert(b);
		b = Binary.add(b, Binary.one(b.length()));
		
		String result = Binary.add(a, b);
		
		if(result.length() > a.length())
			return result.substring(1);
		
		return result;
	}
		
	public static String one(int n){
		if(n < 1)
			return "";		
			
		StringBuilder sb = new StringBuilder();
		
		for(int i = 0; i < n - 1; i++)
			sb.append('0');
		
		sb.append('1');
		
		return sb.toString();
	}
	
	public static String invert(String a){
		StringBuilder sb = new StringBuilder();
		
		for(int i = 0; i < a.length(); i++){
			if(a.charAt(i) == 48)
				sb.append('1');
			else 
				sb.append('0');
		}
		
		return sb.toString();
	}
	
	public static String add(String a, String b){
		if(a == null || b == null)
			return "";
		
		if(a.length() != b.length())
			return "";
		
		StringBuilder sb = new StringBuilder();
		int carry = 0;
		int sum = 0;
		
		for(int i = a.length() - 1; i >= 0; i--){
			sum = carry;
			sum += (a.charAt(i) - 48) + (b.charAt(i) - 48);
			carry = sum >> 1;
			sum &= 1;
			
			if(sum == 0)
				sb.append('0');
			else
				sb.append('1');
		}
		
		if(carry > 0){
			sb.append('1');
		}
		
		return sb.reverse().toString();
	}		
}
