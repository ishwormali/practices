package com.practices.todolist;

import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v7.view.ActionMode;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;
import android.os.Build;

public class MyContextActionBarActivity extends ActionBarActivity {

	protected Object mActionMode;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_my_context_action_bar);

		View editText=findViewById(R.id.myView);
		
		editText.setOnLongClickListener(new View.OnLongClickListener() {
			
			@Override
			public boolean onLongClick(View v) {
				// TODO Auto-generated method stub
				if(mActionMode!=null){
					return false;
					
					
				}
				mActionMode=MyContextActionBarActivity.this.startSupportActionMode(mActionModeCallback);
				
				return true;
			}
		});
	}
	
	

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {

		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
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


	private ActionMode.Callback mActionModeCallback=new ActionMode.Callback() {
		
		@Override
		public boolean onPrepareActionMode(ActionMode arg0, Menu arg1) {
			// TODO Auto-generated method stub
			return false;
		}
		
		@Override
		public void onDestroyActionMode(ActionMode arg0) {
			// TODO Auto-generated method stub
			mActionMode=null;
		}
		
		@Override
		public boolean onCreateActionMode(ActionMode mode, Menu menu) {
			// TODO Auto-generated method stub
			MenuInflater inflater=mode.getMenuInflater();
			inflater.inflate(R.menu.my_context_action_bar, menu);
			
			return true;
		}
		
		@Override
		public boolean onActionItemClicked(ActionMode arg0, MenuItem arg1) {
			// TODO Auto-generated method stub
			switch (arg1.getItemId()) {
			case R.id.toast:
				Toast.makeText(MyContextActionBarActivity.this, 
						"Selected Menu", Toast.LENGTH_SHORT).show();
				arg0.finish();
				return true;
				

			default:
				break;
			}
			return false;
		}
	};
}
