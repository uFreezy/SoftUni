import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class ex03 {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();
		List<String[]> list1 = new ArrayList<String[]>();
		List<String[]> list2 = new ArrayList<String[]>();
		boolean isMatched = true;

		for (int i = 0; i < n; i++) {
			String get = input.nextLine();
			get = get.trim();
			
			if (get.isEmpty()) {
				i--;
			} else {
				String[] buffer = get.split(" ");
				list1.add(buffer);
			}
		}
		
		input.close();
		
		// !
		for (int i = 0; i < list1.size(); i++) {
			for (int k = 0; k < list1.get(i).length; k++) {
				List<String> sBuffer = new ArrayList<String>(Arrays.asList(list1.get(i)));
				for (int j = 0; j < sBuffer.size(); j++) {
					if (sBuffer.get(j).isEmpty()) {
						sBuffer.remove(j);
					}
				}
				
				list1.set(i, sBuffer.toArray(new String[sBuffer.size()]));
			}
		}

		// !
		for (int i = 0; i < n; i++) {
			String get = input.nextLine();
			get = get.trim();
			
			if (get.isEmpty()) {
				i--;
			} else {
				String[] buffer = get.split(" ");
				list2.add(buffer);
			}
		}
		for (int i = 0; i < list2.size(); i++) {
			for (int k = 0; k < list2.get(i).length; k++) {
				List<String> sBuffer = new ArrayList<String>(Arrays.asList(list2.get(i)));
				
				for (int j = 0; j < sBuffer.size(); j++) {
					if (sBuffer.get(j).isEmpty()) {
						sBuffer.remove(j);
					}
				}
				
				list2.set(i, sBuffer.toArray(new String[sBuffer.size()]));
			}
		}
		
		for (int i = 0; i < n - 1; i++) {
			if (!(list1.get(i).length + list2.get(i).length == list1.get(i + 1).length + list2.get(i + 1).length)) {
				isMatched = false;
				break;
			}
		}
		
		if (isMatched) {
			for (int i = 0; i < list1.size(); i++) {
				for (int j = 0; j < list1.get(i).length; j++) {
					String[] buffer = list1.get(i);

					if (j == 0) {
						System.out.printf("[%s,", buffer[j]);
					} else {
						System.out.printf(" %s,", buffer[j]);
					}

				}
				
				List<String> toS = new ArrayList<String>();
				String[] buffer = list2.get(i);
				toS = Arrays.asList(buffer);
				Collections.reverse(toS);
				toS.toArray(buffer);
				
				for (int j = 0; j < list2.get(i).length; j++) {
					if (j == list2.get(i).length - 1) {
						System.out.printf(" %s]", buffer[j]);
					} else {
						System.out.printf(" %s,", buffer[j]);
					}

				}
				
				System.out.println();
			}
		} else {
			int count = 0;
			
			for (int i = 0; i < list1.size(); i++) {
				count += list1.get(i).length;
			}
			
			for (int i = 0; i < list2.size(); i++) {

				count += list2.get(i).length;
			}
			
			System.out.printf("The total number of cells is: %s", count);
		}
	}
}