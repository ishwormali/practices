package com.practices.todolist.db;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.practices.todolist.db.ToDoListDbContract.ToDoListDbEntry;
import com.practices.todolist.domain.ToDoListItem;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

public class ToDoListDataSource {
	ToDoListDbHelper dbHelper;
	public ToDoListDataSource(Context context)
	{
		dbHelper=new ToDoListDbHelper(context);
	
	}
	

	public long InsertToDo(ToDoListItem item){
		Date nowDate=new Date();
		SQLiteDatabase db=dbHelper.getWritableDatabase();
		ContentValues values=new ContentValues();
		values.put(ToDoListDbEntry.COLUMN_NAME_ITEM_NAME, item.getItemName());
		values.put(ToDoListDbEntry.COLUMN_NAME_DATE_CREATED,nowDate.getTime());
		values.put(ToDoListDbEntry.COLUMN_NAME_DATE_UPDATED, nowDate.getTime());
		return db.insert(ToDoListDbEntry.TABLE_NAME, null, values);
		
	}
	
	public List<ToDoListItem> GetAll(){
		SQLiteDatabase db=dbHelper.getReadableDatabase();
		String sortOrder=ToDoListDbEntry.COLUMN_NAME_DATE_UPDATED + " DESC ";
		Cursor cursor=db.query(ToDoListDbEntry.TABLE_NAME, new String[]{ToDoListDbEntry.COLUMN_NAME_ID,ToDoListDbEntry.COLUMN_NAME_ITEM_NAME,ToDoListDbEntry.COLUMN_NAME_DATE_CREATED,ToDoListDbEntry.COLUMN_NAME_DATE_UPDATED}, null, null, null, null, sortOrder);
		int idIdx=cursor.getColumnIndex(ToDoListDbEntry.COLUMN_NAME_ID);
		int itemNameIdx=cursor.getColumnIndex(ToDoListDbEntry.COLUMN_NAME_ITEM_NAME);
		int dateCreatedIdx=cursor.getColumnIndex(ToDoListDbEntry.COLUMN_NAME_DATE_CREATED);
		int dateUpdatedIdx=cursor.getColumnIndex(ToDoListDbEntry.COLUMN_NAME_DATE_UPDATED);
		List<ToDoListItem> items=new ArrayList<ToDoListItem>();
		
		while(cursor.moveToNext()){
			ToDoListItem item=new ToDoListItem();
			int id=cursor.getInt(idIdx);
			String itemName=cursor.getString(itemNameIdx);
			
			Date dateCreated=new Date(cursor.getLong(dateCreatedIdx));
			Date dateUpdated=new Date(cursor.getLong(dateUpdatedIdx));
			item.setId(id);
			item.setItemName(itemName);
			item.setDateCreated(dateCreated);
			item.setDateUpdated(dateUpdated);
			items.add(item);
		}
		cursor.close();
		return items;
	}
	
	
}
