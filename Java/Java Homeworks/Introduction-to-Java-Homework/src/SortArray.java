import java.util.Scanner;
//import java.io.*;
public class SortArray {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String buffer;
		String[] Array = new String[n];
		input.nextLine();
		for(int i = 0; i < n; i++) {
			buffer = input.nextLine();
			Array[i] = buffer;
		}
		for(int i = 0; i < Array.length; i++) {
			for(int k = 0; k < Array.length - i; k++) {
				if(k == Array.length -1) {
					break;
				}
				if(Array[k].compareTo(Array[k+1]) > 0) {
					buffer = Array[k];
					Array[k] = Array[k+1];
					Array[k+1] = buffer;
				}
			}
		}
		for(int i = 0; i < Array.length; i++) {
			System.out.println(Array[i]);
		}
		input.close();
	}

}
