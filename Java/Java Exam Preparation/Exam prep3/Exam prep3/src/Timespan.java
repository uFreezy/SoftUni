import java.util.Scanner;

public class Timespan {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] start = input.nextLine().split(":");
		String[] end = input.nextLine().split(":");
		input.close();
		String result = "";
		
		//The problem can  be optimized to work with methods. 
		if(Integer.parseInt(start[2]) < Integer.parseInt(end[2])) {
			int st = Integer.parseInt(start[2]) + 60;
			int en = Integer.parseInt(end[2]);
			String diff = Integer.toString(st - en);
			start[1] = Integer.toString(Integer.parseInt(start[1]) - 1);
			
			if(Integer.parseInt(diff) < 10) {
				diff = "0" + diff;
			}
			
			result = result + (diff);
		}
		else {
			int st = Integer.parseInt(start[2]);
			int en = Integer.parseInt(end[2]);
			String diff = Integer.toString(st - en);
			
			if(Integer.parseInt(diff) < 10) {
				diff = "0" + diff;
			}
			
			result = result + (diff);
		}
		
		if(Integer.parseInt(start[1]) < Integer.parseInt(end[1])) {
			int st = Integer.parseInt(start[1]) + 60;
			int en = Integer.parseInt(end[1]);
			String diff = Integer.toString(st - en);
			start[0] = Integer.toString(Integer.parseInt(start[0]) - 1);
			
			if(Integer.parseInt(diff) < 10) {
				diff = "0" + diff;
			}
			
			result = (diff) + ":" + result;
		}
		else {
			int st = Integer.parseInt(start[1]);
			int en = Integer.parseInt(end[1]);
			String diff = Integer.toString(st - en);
			
			if(Integer.parseInt(diff) < 10) {
				diff = "0" + diff;
			}
			
			result = (diff) + ":" + result;
		}
		
		String diff = Integer.toString(Integer.parseInt(start[0]) - Integer.parseInt(end[0]));
		result = diff + ":" + result;
		System.out.println(result);
	}
}