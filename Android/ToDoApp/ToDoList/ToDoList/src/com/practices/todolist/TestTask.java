package com.practices.todolist;

import android.os.AsyncTask;
import android.view.MenuItem;

public class TestTask extends AsyncTask<MenuItem,Void,String> {
	MenuItem menuItem;
	@Override
	protected String doInBackground(MenuItem... arg0) {
		menuItem=arg0[0];
		try {
			Thread.sleep(3000);
		} catch (Exception e) {
			// TODO: handle exception
		}
		return null;
	}
	
	@Override
	protected void onPostExecute(String result) {
		//menuItem.collapseActionView();
		menuItem.setActionView(null);
	}

}
