public class Person
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public DateTime DateOfBirth { get; set; }
	public Address Address { get; set; }
	public List<Contract> Constracts { get; set; }
}


public class Address
{
	public int Id { get; set; }
	public string Street { get; set; }
	public string City { get; set; }
	public string ZipCode { get; set; }
}


public class Contract
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Number { get; set; }
	public DateTime Signed { get; set; }
	public bool IsActive { get; set; }
}

public List<Person> LoadData(string path)
{
	var jsonString = File.ReadAllText(path);
	return JsonSerializer.Deserialize<List<Person>>(jsonString);
}

public void SaveData(List<Person> data, string path)
{
	var jsonString = JsonSerializer.Serialize(data);
	File.WriteAllText(path, jsonString);
}
