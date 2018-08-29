import java.util.Scanner;


public class DecToHex {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		int getDec = input.nextInt();
		String getHex = Integer.toHexString(getDec);
		
		System.out.println(getHex);
		

	}

}
