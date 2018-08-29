import java.util.Scanner;
public class SumTwoNumbers {

	public static void main(String[] args) {
		int a,b;
		System.out.println("Enter two integers:");
		Scanner scan = new Scanner(System.in);
		a = scan.nextInt();
		b = scan.nextInt();
		System.out.println(a + b);
		scan.close();
		

	}

}
