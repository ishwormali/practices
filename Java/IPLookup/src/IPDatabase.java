import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Stream;


public class IPDatabase {
	List<IPEntry> entries=new ArrayList<IPEntry>();
	
	public IPDatabase(String dataFilePath) throws IOException{
		List<String> lines=Files.readAllLines(Paths.get( dataFilePath));
		for(String line:lines){
			IPEntry entry=new IPEntry(line);
			entries.add(entry);
		}
		
	}
	
	public String findIPAddress(String domainName){
		for(IPEntry entry:entries){
			if(entry.getDomainName().equals(domainName)){
				return entry.getIp();
			}
			
		}
		
		return null;
	}
	
	public String findDomainName(String ipAddress){
		for(IPEntry entry:entries){
			if(entry.getIp().equals(ipAddress)){
				return entry.getDomainName();
			}
		}
		
		return null;
	}
}
