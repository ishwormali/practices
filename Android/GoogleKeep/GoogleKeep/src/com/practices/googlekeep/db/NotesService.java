package com.practices.googlekeep.db;

import java.sql.Date;
import java.util.ArrayList;
import java.util.List;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

public class NotesService {

	private DbHelper dbHelper;
	public NotesService(Context context){
		this.dbHelper=new DbHelper(context);
	}
	
	public Note CreateNote(Note note){
		SQLiteDatabase db=dbHelper.getWritableDatabase();
		ContentValues values=new ContentValues();
		values.put(DbHelperConstants.COLUMN_NOTE_TITLE, note.getNoteTitle());
		values.put(DbHelperConstants.COLUMN_NOTE_TEXT_CONTENT, note.getTextContent());
		values.put(DbHelperConstants.COLUMN_NOTE_TYPE, note.getNoteType());
		values.put(DbHelperConstants.COLUMN_DATE_CREATED, note.getDateCreated().getTime());
		values.put(DbHelperConstants.COLUMN_DATE_UPDATED, note.getDateUpdated().getTime());
		values.put(DbHelperConstants.COLUMN_NOTE_TEXT_CONTENT, note.getTextContent());
		
		long noteId=db.insert(DbHelperConstants.TABLE_NOTES, null, values);
		note.setNoteId((int)noteId);
		return note;
		
	}
	
	
	public List<Note> getNotes(){
		SQLiteDatabase db= dbHelper.getReadableDatabase();
		String[] columns=new String[]{
			DbHelperConstants.COLUMN__NOTE_ID,
			DbHelperConstants.COLUMN_NOTE_TITLE,
			DbHelperConstants.COLUMN_NOTE_TEXT_CONTENT,
			DbHelperConstants.COLUMN_NOTE_TYPE,
			DbHelperConstants.COLUMN_DATE_CREATED,
			DbHelperConstants.COLUMN_DATE_UPDATED
		};
		Cursor cursor=db.query(DbHelperConstants.TABLE_NOTES, columns, null, null, null, null, DbHelperConstants.COLUMN_DATE_UPDATED + " desc ");
		
		
		
		List<Note> notes=new ArrayList<Note>();
		
		while(cursor.moveToNext()){
			Note note=mapNote(cursor);
			notes.add(note);
		}
		
		return notes;
		
	}
	
	public Note mapNote(Cursor cursor){
		int noteIdIdx=cursor.getColumnIndex(DbHelperConstants.COLUMN__NOTE_ID);
		int noteTitleIdx=cursor.getColumnIndex(DbHelperConstants.COLUMN_NOTE_TITLE);
		int noteTextContentIdx=cursor.getColumnIndex(DbHelperConstants.COLUMN_NOTE_TEXT_CONTENT);
		int noteTypeIdx=cursor.getColumnIndex(DbHelperConstants.COLUMN_NOTE_TYPE);
		int dateCreatedIdx=cursor.getColumnIndex(DbHelperConstants.COLUMN_DATE_CREATED);
		int dateUpdatedIdx=cursor.getColumnIndex(DbHelperConstants.COLUMN_DATE_UPDATED);
		Note note=new Note();
		note.setNoteId(cursor.getInt(noteIdIdx));
		note.setNoteTitle(cursor.getString(noteTitleIdx));
		note.setTextContent(cursor.getString(noteTextContentIdx));
		note.setNoteType(cursor.getInt(noteTypeIdx));
		note.setDateCreated(new Date(cursor.getLong(dateCreatedIdx)));
		note.setDateUpdated(new Date(cursor.getLong(dateUpdatedIdx)));
		
		return note;
		
	}
	
	
}