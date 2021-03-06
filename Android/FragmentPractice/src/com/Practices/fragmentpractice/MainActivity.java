package com.Practices.fragmentpractice;

import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentTransaction;
import android.app.Activity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.os.Build;

public class MainActivity extends FragmentActivity implements HeadlinesFragment.OnHeadlineSelectedListener {

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.news_articles);
		if(findViewById(R.id.fragment_container)!=null){
			if(savedInstanceState!=null){
				return;
			}
			
			HeadlinesFragment firstFragment=new HeadlinesFragment();
			firstFragment.setArguments(getIntent().getExtras());
			getSupportFragmentManager().beginTransaction().add(R.id.fragment_container, firstFragment).commit();
			
		}

	}

	@Override
	public void onArticleSelected(int position) {
		ArticleFragment articleFrag=(ArticleFragment) getSupportFragmentManager().findFragmentById(R.id.article_fragment);
		if(articleFrag!=null){
			articleFrag.updateArticleView(position);
		}
		else{
			ArticleFragment newFragment=new ArticleFragment();
			Bundle args=new Bundle();
			args.putInt(ArticleFragment.ARG_POSITION, position);
			newFragment.setArguments(args);
			FragmentTransaction transaction=getSupportFragmentManager().beginTransaction();
			transaction.replace(R.id.fragment_container, newFragment);
			transaction.addToBackStack(null);
			transaction.commit();
		}
		
	}


}
