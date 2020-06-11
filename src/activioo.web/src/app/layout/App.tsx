import React, { useState, useEffect, Fragment, SyntheticEvent, useContext } from "react";
import "./styles.css";
import { Container } from "semantic-ui-react";
import { IActivity } from "../models/activity";
import NavBar from "../../features/nav/NavBar";
import ActivityDashboard from "../../features/dashboard/ActivityDashboard";
import agent from "../api/agent";
import { LoadingComponent } from './LoadingComponent';
import ActivityStore from '../stores/ActivityStore';
import {observer} from 'mobx-react-lite';

const App = () => {
  const activityStore = useContext(ActivityStore)

  useEffect(() => {
    activityStore.loadActivities();
  }, [activityStore]);
  
  if(activityStore.loadingInitial) return <LoadingComponent content="Loading activities..."/>

  return (
    <Fragment>
      <NavBar/>
      <Container style={{ marginTop: "7em" }}>
        <ActivityDashboard/>
      </Container>
    </Fragment>
  );
};

export default observer(App);
