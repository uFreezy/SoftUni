import java.util.Scanner;


public class TriangleArea {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		int a = input.nextInt();
		int b = input.nextInt();
		int c = input.nextInt();
		int p = (a + b + c) / 2;
		int s = (int)Math.sqrt(p*(p-a)*(p-b)*(p-c));
		
		System.out.println(s);

	}

}