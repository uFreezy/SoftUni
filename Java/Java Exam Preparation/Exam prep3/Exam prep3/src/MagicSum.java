import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class MagicSum {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int d = input.nextInt();
		input.nextLine();
		List<Integer> values = new ArrayList<Integer>();
		int[] maxComb = new int[3];
		Integer[] finalComb = new Integer[3];
		Boolean noMagicSum = true;
		
		while(true) {
			try {
				values.add(input.nextInt());
			}
			catch(Exception e) {
				break;
			}
			
			input.nextLine();
		}
		
		input.close();
		
		for(int a = 0; a < values.size(); a++) {
			for(int b = 0; b < values.size(); b++) {
				for(int c = 0; c < values.size(); c++) {
					Boolean  ifEquals = ifSameIndex(a,b,c);
					if((values.get(a) + values.get(b) + values.get(c)) % d == 0 && !ifEquals) {
						if(values.get(a) + values.get(b) + values.get(c) > 
							maxComb[0] + maxComb[1] + maxComb[2]) {
							maxComb[0] = values.get(a);
							maxComb[1] = values.get(b);
							maxComb[2] = values.get(c);		
						}
						else if(maxComb[0] + maxComb[1] + maxComb[2] == 0) {
							maxComb[0] = values.get(a);
							maxComb[1] = values.get(b);
							maxComb[2] = values.get(c);
						}
						
						noMagicSum = false;
					}
				}
			}
			
		}
		
		if(noMagicSum) {
			System.out.println("No");
		}
		else {
			List<Integer> clone =  new ArrayList<Integer>(values);
			List<Integer> combClone = new ArrayList<Integer>();
			
			for(int ele : maxComb) {
				combClone.add(ele);
			}
			
			clone.removeAll(combClone);
			values.removeAll(clone);
			values.toArray(finalComb);
			char sign = '\u0025';
			Boolean checkIf0 = false;
			
			if(finalComb[0] == null && finalComb[1] == null && finalComb[2] == null) {
				checkIf0 = true;
			}
			
			if(checkIf0) {
				System.out.printf("(0 + 0 + 0) %s %s = 0",sign,d);
			}
			else {
				System.out.printf("(%s + %s + %s) %s %s = 0",finalComb[0],
						finalComb[1],finalComb[2],sign,d);
			}
		}	
	}
	
	public static Boolean ifSameIndex(int a, int b, int c) {
		 Boolean Check = false;
		 
		 if(a == b || a == c || b == c) {
			 Check = true;
		 }
		 
		 return Check;
	}

}
