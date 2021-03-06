package com.practices.todolist;

import com.practices.todolist.R.id;

import android.R.color;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.ActionBarDrawerToggle;
import android.support.v4.app.Fragment;
import android.support.v4.widget.DrawerLayout;
import android.content.res.Configuration;
import android.graphics.Color;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.os.Build;

public class MyDrawerActivity extends ActionBarActivity implements ListView.OnItemClickListener {

	private DrawerLayout mDrawerLayout;
	private ListView mDrawerList;
	private String[] mTitles;
	private CharSequence title;
	private ActionBarDrawerToggle mDrawerToggle ;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_my_drawer);

		title=getActionBar().getTitle();
		mDrawerLayout=(DrawerLayout)findViewById(id.drawer_layout);
		mDrawerList=(ListView)findViewById(R.id.left_drawer);
		mTitles=getResources().getStringArray(R.array.operating_systems);
		
		mDrawerList.setAdapter(new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1,mTitles)
				{
			@Override
			public View getView(int position, View convertView, ViewGroup parent) {
				TextView view=(TextView)super.getView(position, convertView, parent);
				view.setTextColor(Color.GREEN);
				return view;
			};
				}
				);
		
		mDrawerToggle=new ActionBarDrawerToggle(this, mDrawerLayout, R.drawable.ic_drawer, R.string.drawer_open, R.string.drawer_close){
			public void onDrawerClosed(View drawerView) {
				getActionBar().setTitle(title);
			};
			
			@Override
			public void onDrawerOpened(View drawerView) {
				// TODO Auto-generated method stub
			getActionBar().setTitle("Open Drawer");
			}
		};
		
		mDrawerList.setOnItemClickListener(new AdapterView.OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> arg0, View arg1, int position,
					long arg3) {
				selectItem(position);
				
			}
			
		});
		
		mDrawerLayout.setDrawerListener(mDrawerToggle);
		getActionBar().setDisplayHomeAsUpEnabled(true);
		
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {

		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.my_drawer, menu);
		return super.onCreateOptionsMenu(menu);
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		if(mDrawerToggle.onOptionsItemSelected(item)){
			return true;
		}
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	public void onItemClick(AdapterView<?> arg0, View arg1, int position, long arg3) {
		selectItem(position);
		
	}
	
	@Override
	protected void onPostCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onPostCreate(savedInstanceState);
		mDrawerToggle.syncState();
	}
	
	@Override
	public void onConfigurationChanged(Configuration newConfig) {
		// TODO Auto-generated method stub
		super.onConfigurationChanged(newConfig);
		mDrawerToggle.onConfigurationChanged(newConfig);
	}
	
	private void selectItem(int position){
		OperationSystemFragment fragment=new OperationSystemFragment();
//		Bundle bundle=new Bundle();
//		bundle.putInt(OperationSystemFragment.ARG_OS, position);
		String title=mTitles[position];
		fragment.setTextTitle(title);
		getSupportFragmentManager().beginTransaction().replace(R.id.content_frame, fragment).commit();
		
		mDrawerList.setItemChecked(position, true);
		getActionBar().setTitle(title);
		mDrawerLayout.closeDrawer(mDrawerList);
	}

	

}
