import java.util.Scanner;

public class SymmetricNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] getInp = input.nextLine().split(" ");
		input.close();
		int min = Integer.parseInt(getInp[0]);
		int max = Integer.parseInt(getInp[1]);
		int counter = min;
		int cNextLine = 0;
		
		do {
			String counterS = Integer.toString(counter);
			if(cNextLine == 10) {
				System.out.println();
				cNextLine = 0;
			}
		    if(counter < 10) {
		    	
		    	System.out.printf("%s ",counter);
		    	cNextLine++;
			}
			else if(counterS.length() == 2 && 
					counterS.charAt(0) == counterS.charAt(1)){
				
				System.out.printf("%s ",counter);
				cNextLine++;
			}
			else if(counterS.length() == 3 && 
				    counterS.charAt(0) == counterS.charAt(2)){
				
				System.out.printf("%s ",counter);
				cNextLine++;
			}
		    
			counter++;
	    }
		while(counter <= max);
	}														
}
