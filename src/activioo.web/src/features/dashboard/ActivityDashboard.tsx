import React, { SyntheticEvent, useContext } from "react";
import { Grid, GridColumn } from "semantic-ui-react";
import { IActivity } from "../../app/models/activity";
import  ActivityList from "./ActivityList";
import ActivityDetails from "./../details/ActivityDetails";
import ActivityForm from "./../form/ActivityForm"
import { observer } from "mobx-react-lite";
import ActivityStore from "../../app/stores/ActivityStore";

interface IProps {
  activities: IActivity[];
  setEditMode: (editMode: boolean) => void;
  setSelectedActivity: (activity: IActivity | null) => void;
  editActivity: (activity: IActivity) => void;
  deleteActivity: (e: SyntheticEvent<HTMLButtonElement> , id: string) => void;
  submitting: boolean;
  target: string;
}


const ActivityDashboard: React.FC<IProps> = ({
  setEditMode,
  setSelectedActivity,
  editActivity,
  deleteActivity,
  submitting,
  target
}) => {
  const activityStore = useContext(ActivityStore);
  const {editMode, selectedActivity} = activityStore
  return (
    <Grid>
      <GridColumn width={10}>
        <ActivityList
          deleteActivity={deleteActivity}
          submitting={submitting}
          target={target}
        />
      </GridColumn>
      <Grid.Column width={6}>
        {selectedActivity && !editMode && (
          <ActivityDetails
            setEditMode={setEditMode}
            setSelectedActivity={setSelectedActivity}
          />
        )}
        {editMode && (
          <ActivityForm
            key={(selectedActivity && selectedActivity.id || 0)}
            activity={selectedActivity!}
            setEditMode={setEditMode}
            editActivity={editActivity}
            submitting={submitting}
          />
        )}
      </Grid.Column>
    </Grid>
  );
};
export default observer(ActivityDashboard)