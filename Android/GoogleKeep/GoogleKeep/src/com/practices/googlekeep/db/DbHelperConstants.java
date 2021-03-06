package com.practices.googlekeep.db;

public final class DbHelperConstants {


	public static String TABLE_NOTES="NOTES";
	public static String COLUMN__NOTE_ID="NOTE_ID";
	public static String COLUMN_NOTE_TITLE="NOTE_TITLE";
	public static String COLUMN_NOTE_TEXT_CONTENT="NOTE_CONTENT";
	public static String COLUMN_NOTE_TYPE="NOTE_TYPE";
	public static String COLUMN_DATE_CREATED="DATE_CREATED";
	public static String COLUMN_DATE_UPDATED="DATE_UPDATED";
	public static String TEXTTYPE=" TEXT ";
	public static String INTTYPE=" INT ";
	
	public static String COMMA=" , ";
	
	public static final String CreateTableNote="CREATE TABLE "+TABLE_NOTES + "( " +
			COLUMN__NOTE_ID + INTTYPE +" PRIMARY KEY AUTOINCREMENT " + COMMA +
			COLUMN_NOTE_TITLE + TEXTTYPE+COMMA+
			COLUMN_NOTE_TEXT_CONTENT + TEXTTYPE + COMMA +
			COLUMN_DATE_CREATED + INTTYPE + COMMA +
			COLUMN_DATE_UPDATED + INTTYPE + COMMA +
			COLUMN_NOTE_TYPE + INTTYPE +
			")";

	public static final String DropTableNote="DROP TABLE IF EXISTS "+	TABLE_NOTES;
	
}
