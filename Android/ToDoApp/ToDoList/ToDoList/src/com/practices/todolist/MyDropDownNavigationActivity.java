package com.practices.todolist;

import android.support.v7.app.ActionBar.OnNavigationListener;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.os.Build;

public class MyDropDownNavigationActivity extends ActionBarActivity implements OnNavigationListener {
	
	private String[] os;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_my_drop_down_navigation);

		
		ActionBar actionBar=getSupportActionBar();
		actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_LIST);
		os=getResources().getStringArray(R.array.operating_systems);
		ArrayAdapter<String> arrAdapter=new ArrayAdapter<String>
		(getSupportActionBar().getThemedContext(), android.R.layout.simple_spinner_item,os);
		arrAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		actionBar.setListNavigationCallbacks(arrAdapter, this);
		actionBar.setDisplayShowTitleEnabled(false);

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {

		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.my_drop_down_navigation, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	public boolean onNavigationItemSelected(int position, long id) {
		// TODO Auto-generated method stub
		MySubTabActivity secondAct=new MySubTabActivity();
		Bundle args=new Bundle();
		String osText=os[position];
		args.putString(MyNavigationTabActivity.STATE_SELECTED_NAVIGATION_ITEM, osText);
		secondAct.setArguments(args);
		getSupportFragmentManager().beginTransaction().replace(R.id.container, secondAct).commit();
		
		return true;
	}


}
