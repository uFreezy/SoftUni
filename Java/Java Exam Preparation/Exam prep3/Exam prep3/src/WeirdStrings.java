import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class WeirdStrings {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String rawInp = input.nextLine();
		input.close();
		rawInp = rawInp.replaceAll("[\\(\\)\\|\\/\\u005c\\ ]", "");
		String[] words = rawInp.split("(\\W)|(\\d)|(\\_)"); // '_' isnt included in \\W
		List<String> wordsList = new ArrayList<String>(Arrays.asList(words));
		
		// 2 years later i have no idea why this is here but im afraid to remove it.
		while(wordsList.remove("")); 
		
		int bIndx1 = 0;
		int bIndx2 = 0;
		int biggestSum = 0;
		
		for(int i = 0; i < wordsList.size() -2; i++) {
			int weight1 = getWeight(wordsList.get(i).toCharArray()) 
					+ getWeight(wordsList.get(i+1).toCharArray());
			int weight2 = getWeight(wordsList.get(i+1).toCharArray()) 
					+ getWeight(wordsList.get(i+2).toCharArray());
			
			if(weight1 > weight2 &&  weight1 > biggestSum) {
				bIndx1 = i;
				bIndx2 = i+1;
				biggestSum = weight1;
			}
			else if (weight1 == weight2) {
				if(weight1 == biggestSum) {
					bIndx1 = i+1;
					bIndx2 = i+2;
				}
				else if (weight1 > biggestSum) {
					bIndx1 = i+1;
					bIndx2 = i+2;
					biggestSum = weight1;
				}
			}
			else if (weight1 < weight2 && weight2 > biggestSum) {
				bIndx1 = i+1;
				bIndx2 = i+2;
				biggestSum = weight2;
			}
		}
		
		System.out.println(wordsList.get(bIndx1));
		System.out.println(wordsList.get(bIndx2));	
	}
	
	public static int getWeight(char[] c) {
		int result = 0;
		
		for(int i = 0; i < c.length; i++) {
			result += (Character.isUpperCase(c[i]) ? 1 + (c[i] - 'A') : 1 + (c[i] - 'a'));
		}
		
		return result;
	}
}