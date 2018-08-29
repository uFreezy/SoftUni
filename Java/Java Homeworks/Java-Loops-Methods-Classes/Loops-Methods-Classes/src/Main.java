import java.util.TreeMap;

public class Main {

	public static void main(String[] args) {		
		TreeMap<Integer,String> newMap = new TreeMap<>();
		newMap.put(2,"entry 1");
		newMap.put(5,"entry 2");
		newMap.put(1,"entry 3");
		System.out.println(newMap);
	}

}
