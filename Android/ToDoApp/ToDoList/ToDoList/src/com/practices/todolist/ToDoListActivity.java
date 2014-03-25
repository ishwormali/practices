package com.practices.todolist;

import java.util.ArrayList;
import java.util.List;

import com.practices.todolist.db.ToDoListDataSource;
import com.practices.todolist.db.ToDoListDbHelper;

import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;
import android.os.Build;
import com.practices.todolist.domain.ToDoListItem;

public class ToDoListActivity extends ActionBarActivity {
	ToDoItemAdapter aa;
	ToDoListDataSource dataSource;
	ArrayList<ToDoListItem> todoItems;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);

		final EditText myEditText=(EditText)findViewById(R.id.myEditText);
		final ListView myListView=(ListView)findViewById(R.id.myListView);
		
		dataSource=new ToDoListDataSource(this);
		
		todoItems=new ArrayList<ToDoListItem>();
		aa=new ToDoItemAdapter(this, this.getLayoutInflater(),todoItems);
		
		myListView.setAdapter(aa);
		myEditText.setOnKeyListener(new View.OnKeyListener() {
			
			@Override
			public boolean onKey(View v, int keyCode, KeyEvent event) {
				// TODO Auto-generated method stub
				if(event.getAction()==KeyEvent.ACTION_DOWN){
					if(keyCode==KeyEvent.KEYCODE_DPAD_CENTER||
					keyCode==KeyEvent.KEYCODE_ENTER){
						insertItem(myEditText.getText().toString());
						
						//todoItems.add(0,myEditText.getText().toString());
						//aa.notifyDataSetChanged();
						myEditText.setText("");
						loadData();
						return true;
					}
				}
				return false;
			}
		
		});
		
		myListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> arg0, View arg1, int arg2,
					long arg3) {
				ToDoListItem item=(ToDoListItem)arg0.getItemAtPosition(arg2);
				Toast.makeText(ToDoListActivity.this, item.getItemName(), Toast.LENGTH_SHORT).show();
				
			}
			
			
		});
		
		loadData();
	}
	
	private Boolean insertItem(String todo){
		ToDoListItem item=new ToDoListItem();
		item.setItemName(todo);
		long insertedRow=dataSource.InsertToDo(item);
		return insertedRow==1;
	}
	
	private void loadData(){
		List<ToDoListItem> items= dataSource.GetAll();
		todoItems.clear();
		for(int i=0;i<items.size();i++){
			ToDoListItem item=items.get(i);
			todoItems.add(item);
		}
		
		aa.notifyDataSetChanged();
	}
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {

		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.to_do_list, menu);
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

	/**
	 * A placeholder fragment containing a simple view.
	 */
	public static class PlaceholderFragment extends Fragment {

		public PlaceholderFragment() {
		}

		@Override
		public View onCreateView(LayoutInflater inflater, ViewGroup container,
				Bundle savedInstanceState) {
			View rootView = inflater.inflate(R.layout.fragment_to_do_list,
					container, false);
			return rootView;
		}
	}

}
