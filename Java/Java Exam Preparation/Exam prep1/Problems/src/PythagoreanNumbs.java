import java.util.Scanner;

public class PythagoreanNumbs {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		int[] c = new int[n];
		Boolean check = false;
		
		for(int i = 0; i < c.length; i++) {
			c[i] = input.nextInt();
		}
		input.close();
		
		for(int i = 0; i < c.length; i++) {
			for(int a = 0; a < c.length; a++) {
				for(int b = 0; b < c.length; b++) {
					if((c[a]*c[a]) + (c[b]*c[b]) == (c[i]*c[i]) && c[a] <= c[b]) {
						System.out.println(c[a]+"*"+c[a]+" + "+c[b]+"*"+c[b]
								+" = "+c[i]+"*"+c[i]);
						check = true;
					}
				}
			}
		}
		if(check == false) {
			System.out.println("No");
		}
	}
}
