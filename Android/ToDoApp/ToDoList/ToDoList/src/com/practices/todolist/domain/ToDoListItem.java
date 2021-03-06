package com.practices.todolist.domain;

import java.util.Date;

public final class ToDoListItem {
	private int id;
	
	public int getId(){
		return id;
	}
	public void setId(int id){
		this.id=id;
		
	}
	
	private	String itemName;
	public String getItemName(){
		return itemName;
	}
	public void setItemName(String itemName){
		this.itemName=itemName;
	}
	
	private Date dateCreated;
	public Date getDateCreated(){
		return dateCreated;
	}
	
	public void setDateCreated(Date dateCreated){
		this.dateCreated=dateCreated;
	}
	
	private Date dateUpdated;
	public Date getDateUpdated(){
		return dateUpdated;
	}
	
	public void setDateUpdated(Date dateUpdated){
		this.dateUpdated=dateUpdated;
	}
}
