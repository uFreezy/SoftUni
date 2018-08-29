import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;

public class Nuts {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();
		List<String> getInp = new ArrayList<String>();
		
		for(int i = 0; i < n; i++) {
			getInp.add(input.nextLine());
		}
		
		input.close();
		
		for(String ele : getNamesByOrder(getInp)) {
			System.out.printf("%s:%s",ele,getNuts(getInp,ele));
			System.out.println();
		}

		System.out.println(getType(getInp));
	}
	
	public static List<String> getNamesByOrder(List<String> inp){
		List<String> out = new ArrayList<String>();
	
		for(String ele : inp) {
			out.add(ele.substring(0, ele.indexOf(" ")));
		
		}
		
		Set<String> clear = new HashSet<String>(out);
		out.clear();
		out.addAll(clear);
		Collections.sort(out);
		
		return out;
	}
	
	public static List<String> getType(List<String> inp){
		List<String> output = new ArrayList<String>();
	
		for(String ele : inp) {
			output.add(ele.substring(ele.indexOf(" "), ele.lastIndexOf(" ")));
		}
		
		Set<String> buffer = new LinkedHashSet<String>(output);
		output.clear();
		output.addAll(buffer);
		
		return output;
	}
	
	public static String getNuts(List<String> inp,String name) {
		String out = "";
		List<String> types = new ArrayList<String>(getType(inp));
		Map<String,Integer> map = new HashMap<String,Integer>();
		
		for(int i = 0; i < inp.size(); i++) {
			if(inp.get(i).contains(name)) {
				String key = inp.get(i).substring(inp.get(i).indexOf(" "), inp.get(i).lastIndexOf(" "));
				int value = Integer.parseInt(inp.get(i).substring(inp.get(i).lastIndexOf(" ")+1, inp.get(i).length()-2));
	
				if(map.containsKey(key)) {
					map.replace(key, map.get(key), (map.get(key)+value));
				}
				else {
					map.put(key ,value);
				}
			}
		}
		
		for(String ele : types) {
		    if(map.containsKey(ele)) {
				out += ele + "-" + map.get(ele) + "kg,";
			}
		}
		
		out = out.substring(0, out.length()-1);
	  
		return out;
	}
}