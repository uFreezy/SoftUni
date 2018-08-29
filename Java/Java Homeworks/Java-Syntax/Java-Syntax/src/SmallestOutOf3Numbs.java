import java.util.Scanner;


public class SmallestOutOf3Numbs {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		double a = input.nextDouble();
		double b = input.nextDouble();
		double c = input.nextDouble();
		
		if(a < b) {
			if(a < c) {
				System.out.println(a);
			}
			else {
				System.out.println(c);
			}
		}
		else if(b < a) {
			if(b < c) {
				System.out.println(b);
			}
			else {
				System.out.println(c);
			}
		}
		else if(c < a) {
			if(c < b) {
				System.out.println(c);
			}
			else {
				System.out.println(b);
			}
		}

	}

}
