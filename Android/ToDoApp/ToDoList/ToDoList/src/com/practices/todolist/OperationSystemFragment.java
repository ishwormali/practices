package com.practices.todolist;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView.FindListener;
import android.widget.TextView;

public class OperationSystemFragment extends Fragment {
	public static final String ARG_OS="OS";
	private String title;
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		View view=inflater.inflate(R.layout.fragment__operating_system, container,false);
		TextView textView=(TextView)view.findViewById(R.id.textView);
		
		if(textView!=null){
			textView.setText(title);
		}
		return view;
	}
	
	public void setTextTitle(String title){
		this.title=title;
	}
}
