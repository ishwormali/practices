package com.practices.todolist.db;

import android.provider.BaseColumns;

public final class ToDoListDbContract {
	
	
	public static abstract class ToDoListDbEntry implements BaseColumns{
		public static final String TABLE_NAME="TODOLIST";
		public static final String COLUMN_NAME_ID="ID";
		public static final String COLUMN_NAME_ITEM_NAME="ITEM_NAME";
		public static final String COLUMN_NAME_DATE_CREATED="DATE_CREATED";
		public static final String COLUMN_NAME_DATE_UPDATED="DATE_UPDATED";
		
	}
	
	public static final String TEXT_TYPE=" TEXT ";
	public static final String INT_TYPE=" int ";
	public static final String COMMA_SEP=" , ";
	public static final String SQL_CREATE_TABLE=
			"CREATE TABLE "+ ToDoListDbEntry.TABLE_NAME + "(" +
					ToDoListDbEntry.COLUMN_NAME_ID +" INTEGER PRIMARY KEY AUTOINCREMENT" + COMMA_SEP +
					ToDoListDbEntry.COLUMN_NAME_ITEM_NAME + TEXT_TYPE + COMMA_SEP +
					ToDoListDbEntry.COLUMN_NAME_DATE_CREATED + INT_TYPE+COMMA_SEP+
					ToDoListDbEntry.COLUMN_NAME_DATE_UPDATED + INT_TYPE + " )";
					
	public static final String SQL_DROP_TABLE=
			"DROP TABLE IF EXISTS "+ToDoListDbEntry.TABLE_NAME;

}
