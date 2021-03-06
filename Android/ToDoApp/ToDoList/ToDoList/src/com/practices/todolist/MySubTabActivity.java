package com.practices.todolist;

import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.os.Build;

public class MySubTabActivity extends Fragment {
	private String selectedTabTitle="";
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		View view=inflater.inflate(R.layout.activity_my_sub_tab, container,false);
		TextView txtView=(TextView)view.findViewById(R.id.tab_content_textview);
		txtView.setText(selectedTabTitle);
		return view;
	}
			
	
	@Override
	public void setArguments(Bundle args) {
		// TODO Auto-generated method stub
		super.setArguments(args);
		if(args.containsKey(MyNavigationTabActivity.STATE_SELECTED_NAVIGATION_ITEM)){
			selectedTabTitle=args.getString(MyNavigationTabActivity.STATE_SELECTED_NAVIGATION_ITEM);
		}
	}

	

}
