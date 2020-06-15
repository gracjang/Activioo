import React, { useContext } from "react";
import { Grid, GridColumn } from "semantic-ui-react";
import ActivityList from "./ActivityList";
import ActivityDetails from "./../details/ActivityDetails";
import ActivityForm from "./../form/ActivityForm"
import { observer } from "mobx-react-lite";
import ActivityStore from "../../app/stores/ActivityStore";


const ActivityDashboard: React.FC = () => {
  const activityStore = useContext(ActivityStore);
  const {editMode, activity: activity} = activityStore
  return (
    <Grid>
      <GridColumn width={10}>
        <ActivityList/>
      </GridColumn>
      <Grid.Column width={6}>
        <h2>Activity filters</h2>
      </Grid.Column>
    </Grid>
  );
};
export default observer(ActivityDashboard)