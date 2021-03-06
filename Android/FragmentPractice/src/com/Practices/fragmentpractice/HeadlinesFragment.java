package com.Practices.fragmentpractice;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.ListFragment;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class HeadlinesFragment extends ListFragment {

	OnHeadlineSelectedListener mCallback;
	
	
	@Override
	public void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setListAdapter(new ArrayAdapter<String>(getActivity(),android.R.layout.simple_list_item_1,Ipsum.Headlines));
		
	}

	@Override
	public void onStart() {
		// TODO Auto-generated method stub
		super.onStart();
		
		if(getFragmentManager().findFragmentById(R.id.article_fragment)!=null){
			getListView().setChoiceMode(ListView.CHOICE_MODE_SINGLE);
		}
	}

	
	public interface OnHeadlineSelectedListener{
		public void onArticleSelected(int position);
	}
	
	@Override
	public void onAttach(Activity activity) {
		// TODO Auto-generated method stub
		super.onAttach(activity);
		try{
			mCallback=(OnHeadlineSelectedListener)activity;
		}
		catch(ClassCastException ex){
			throw new ClassCastException(activity.toString()+ " must implement OnHeadlineSelectedListener");
		}
	}
	

	@Override
	public void onListItemClick(ListView l, View v, int position, long id) {
		// TODO Auto-generated method stub
		//super.onListItemClick(l, v, position, id);
		mCallback.onArticleSelected(position);
		getListView().setItemChecked(position, true);
	}


}


