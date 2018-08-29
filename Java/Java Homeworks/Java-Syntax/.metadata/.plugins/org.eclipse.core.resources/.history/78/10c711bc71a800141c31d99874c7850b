import java.util.Scanner;


public class CountOfBitsOne {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		int a = input.nextInt();
		int counter = 0;
		
		System.out.println(Integer.toBinaryString(a));
		for(int i = 0; i < 32; i++){
			
			if((1 & a) == 1) {
				counter++;
			}
			a = a >>> 1;
		}
		
		System.out.println(counter);

	}

}
