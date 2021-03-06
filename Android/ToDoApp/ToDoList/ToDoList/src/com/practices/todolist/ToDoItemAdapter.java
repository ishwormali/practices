package com.practices.todolist;

import java.util.List;

import com.practices.todolist.db.ToDoListDataSource;
import com.practices.todolist.domain.ToDoListItem;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

public class ToDoItemAdapter extends BaseAdapter {
	
	LayoutInflater inflater;
	List<ToDoListItem> items;
	public ToDoItemAdapter(Context context,LayoutInflater inflater,List<ToDoListItem> items){
		
		this.items=items;
		this.inflater=inflater;
	}
	
	public List<ToDoListItem> getItems(){
		return items;
	}
	
	public void setItems(List<ToDoListItem> items){
		this.items=items;
	}
	
	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return items.size();
	}

	@Override
	public Object getItem(int arg0) {
		// TODO Auto-generated method stub
		return items.get(arg0);
	}

	@Override
	public long getItemId(int arg0) {
		// TODO Auto-generated method stub
		return items.get(arg0).getId();
	}

	@Override
	public View getView(int arg0, View arg1, ViewGroup arg2) {
		// TODO Auto-generated method stub
		if(arg1==null){
			arg1=inflater.inflate(R.layout.todolistitemview, arg2,false);
			
		}
		
		TextView itemName=(TextView)arg1.findViewById(R.id.todoitem_itemname);
		TextView dateCreated=(TextView)arg1.findViewById(R.id.todoitem_datecreated);
		ToDoListItem todoItem=(ToDoListItem)items.get(arg0);
		itemName.setText(todoItem.getItemName());
		dateCreated.setText(todoItem.getDateCreated().toString());
		
		return arg1;
	}

}
