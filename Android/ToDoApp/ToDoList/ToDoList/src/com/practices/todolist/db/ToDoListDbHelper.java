package com.practices.todolist.db;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.practices.todolist.db.ToDoListDbContract.ToDoListDbEntry;
import com.practices.todolist.domain.ToDoListItem;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteDatabase.CursorFactory;
import android.database.sqlite.SQLiteOpenHelper;

public class ToDoListDbHelper extends SQLiteOpenHelper {

	
	public ToDoListDbHelper(Context context) {
		super(context, DATABASE_NAME, null, DATABASE_VERSION);
		// TODO Auto-generated constructor stub
	}

	public static final int DATABASE_VERSION=2;
	public static final String DATABASE_NAME="ToDoList.db";
	
	@Override
	public void onCreate(SQLiteDatabase db) {
		db.execSQL(ToDoListDbContract.SQL_CREATE_TABLE);

	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		db.execSQL(ToDoListDbContract.SQL_DROP_TABLE);
		onCreate(db);

	}

}
