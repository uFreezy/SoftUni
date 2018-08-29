import java.util.Scanner;

public class LongestOddEvenSeq {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String getInp = input.nextLine();
		input.close();
		int valNumb =  getInp.length() - getInp.replaceAll("\\)", "").length();
		int[] values = new int[valNumb];
		String[] strBuff = getInp.split("\\)");
		int bCount = 0;
		int cCount = 0;
		Boolean begin = true;
		
		for(int i = 0; i < valNumb; i++) {
			values[i] = Integer.parseInt(strBuff[i].replaceAll("\\W", ""));
		}
		
		for(int i = 0; i < valNumb-1; i++) {
			if(values[i] % 2 == 0 && values[i+1] == 0) {
				values[i+1] = 3;
			}
			else if(values[i] % 2 != 0 && values[i+1] == 0) {
				values[i+1] = 2;
			}
			
			if(values[i] % 2 == 0 && values[i+1] % 2 != 0 || 
					values[i] % 2 != 0 && values[i+1] % 2 == 0) {
				if(begin) {
					cCount += 2;
					begin = false;
				}
				else {
					cCount++;
				}
				if(cCount > bCount) {
					bCount = cCount;
				}
			}
			else {
				cCount = 0;
				begin = true;
			}
		}
		System.out.println(bCount);
	}
}
