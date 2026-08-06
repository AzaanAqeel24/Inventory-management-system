using System;
using System.Collections.Generic;
					
public class Product
{
	public string name;
	public int quantity;
	public double price;
	
	//Paramitrized Constructor
	public Product(string Name,int Quantity,double Price){
	    name=Name;
		quantity=Quantity;
		price=Price;
	}
	//Non-Paramitrized Constructor
	public Product(){
	    name="";
		quantity=0;
		price=0;
	}
	//Add function
	public static void AddProduct(List<Product> inventory){
		//Inputs and their validations
	    Console.WriteLine("Enter the Name of the product");
		string name=Console.ReadLine();
		//check if the product with this name already exist in the inventory
		if(FindProduct(inventory,name)!=-1){
			//if exist then inform the user and reutrn
		    Console.WriteLine($"Product {name} already exit in the inventory.");
			return;
		}
		//if not then add
		InvalidPrice:
		Console.WriteLine("Enter the Price of the product");
		double price=double.Parse(Console.ReadLine());
		//price cannot be -ve or 0
		if(price<=0){
			Console.WriteLine("Invalid Price. Enter a positive Price");
			goto InvalidPrice;
		}
		InvalidQuantity:
		Console.WriteLine("Enter the Quantity of the product");
		int quantity=int.Parse(Console.ReadLine());
		//quanity cannot be -ve 
		if(quantity<0){
			Console.WriteLine("Invalid Quantity. Enter a Positive Value");
			goto InvalidQuantity;
		}
		//creating product and adding into inventory
		Product product=new  Product(name,quantity,price);
		inventory.Add(product);
		Console.WriteLine($"Product: {product.name} successfullt added..");
	}
	//Finding a product in the inventory
	public static int FindProduct(List<Product> inventory,string name){
		//check if the product  exist in the inventory
		for(int i=0;i<inventory.Count;i++){
			//if exist then return true otherwise false 
		    if(name == inventory[i].name){
			    return i;
			}
		}
		return -1;
	}
	//Update Stock Funcion
	public static void UpdateStock(List<Product> inventory){
		int choice;
	    if(inventory.Count!=0){
		    //Input the name of the product whose stocks you want to update
	        Console.WriteLine("Enter the Name of the product whose stocks you want to update");
		    string name=Console.ReadLine();
		    //check if the product  exist in the inventory
		    int position=FindProduct(inventory,name);
			if(position!=-1){
				//if found
			    Console.WriteLine("Choose operation");
				Console.WriteLine("1-Restock");
				Console.WriteLine("2-Sell stock");
				Console.Write("Enter Your Choice: ");
			    do{
				    choice=int.Parse(Console.ReadLine());
				}while(choice!=1 && choice!=2);    //choice validation
				switch(choice){
					case 1:
						//restock
						Console.WriteLine($"Enter the quantity of stock you want to add for Product {name}");
						inventory[position].quantity+=int.Parse(Console.ReadLine());
						break;
					case 2:
						//selling stock
						int sellquantity;
						Console.WriteLine($"Enter the quantity of stock you want to sell for Product {name}");
						sellquantity=int.Parse(Console.ReadLine());
						if(sellquantity<=inventory[position].quantity){
						    inventory[position].quantity-=sellquantity;
						}else{
							Console.WriteLine("Not Enough Stock Available");
							return;
						}
						break;
				}
			}else
				Console.WriteLine($"Product {name} not found in the inventory.");
		}else
			Console.WriteLine("Inventory is Empty");
	}
	//Display Inventory Function
	public static void DisplayInventory(List<Product> inventory){
		//Check if the inventory is empty
	    if(inventory.Count==0){
			Console.WriteLine("Inventory is empty");
			return;
		}
		//Show Inventory details
		Console.WriteLine("<====Inventory Details====>");
	    for(int i=0;i<inventory.Count;i++){
            Console.WriteLine($"Product {i+1} : \nName - {inventory[i].name}\nPrice - {inventory[i].price}Rs\nQuantity - {inventory[i].quantity}\n");

		}	
	}
	//Remove Product Function
	public static void RemoveProduct(List<Product> inventory){
	    //Input the name of the product you want to remove from inventory
	    Console.WriteLine("Enter the Name of the product you want to remove form Inventory");
		string name=Console.ReadLine();
		//check if the product  exist in the inventory
		int position=FindProduct(inventory,name);
		if(position!=-1){
			//found 
		    Console.WriteLine($"Product Details\nName - {inventory[position].name}\nPrice - {inventory[position].price}Rs\nQuantity - {inventory[position].quantity}");
			Console.WriteLine("Confirm delete (yes/no)");
			string choice=Console.ReadLine();
			if(choice.ToLower()=="yes"){
				//remove product from inventory only when confirmed form user
                inventory.RemoveAt(position);
				Console.WriteLine($"Product {name} is successfully removed from inventory");
			}else    
				Console.WriteLine("Deletion Cencel");
		}else{
			//Product not found in inventory
		    Console.WriteLine($"Product {name} not found in the inventory.");
			return;
		}
	}
	public static void Main()
	{
		int choice=0;
		List<Product> Inventory=new  List<Product>();
		//<===================================>
		//<===============Menu================>
		//<===================================>
		do{
		    Console.WriteLine("<==========Menu==========>");
		    Console.WriteLine("Press 1 for Adding a product in inventory.");
		    Console.WriteLine("Press 2 for Updating stocks in inventory.");
		    Console.WriteLine("Press 3 for Viewing the products in inventory.");
		    Console.WriteLine("Press 4 Removing Product form inventory.");
		    Console.WriteLine("Press 5 to Exit.");
			Console.Write("Enter Your Choice: ");
			choice=int.Parse(Console.ReadLine());
			switch (choice){
				case 1:
					AddProduct(Inventory);
					break;
				case 2:
					UpdateStock(Inventory);
					break;
				case 3:
					DisplayInventory(Inventory);
					break;
				case 4:
					RemoveProduct(Inventory);
					break;
				case 5:
					break;
				default:
			        Console.WriteLine("Invalid input Please Enter a valid Input...(1--5)");
					break;
			}
		}while(choice!=5);
		Console.WriteLine("Thank u for visiting the Inventory;");
	}
}
