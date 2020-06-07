import React from "react";
import { Grid, GridColumn } from "semantic-ui-react";
import { IActivity } from "../../app/models/activity";
import { ActivityList } from "./ActivityList";
import { ActivityDetails } from "./../details/ActivityDetails";
import { ActivityForm } from "./../form/ActivityForm";

interface IProps {
  activities: IActivity[];
  selectActivity: (id: string) => void;
  selectedActivity: IActivity | null;
  editMode: boolean;
  setEditMode: (editMode: boolean) => void;
  setSelectedActivity: (activity: IActivity | null) => void;
  createActivity: (activity: IActivity) => void;
  editActivity: (activity: IActivity) => void;
  deleteActivity: (id: string) => void;
}

export const ActivityDashboard: React.FC<IProps> = ({
  activities,
  selectActivity,
  selectedActivity,
  editMode,
  setEditMode,
  setSelectedActivity,
  createActivity,
  editActivity,
  deleteActivity
}) => {
  return (
    <Grid>
      <GridColumn width={10}>
        <ActivityList activities={activities} selectActivity={selectActivity} deleteActivity={deleteActivity}/>
      </GridColumn>
      <Grid.Column width={6}>
        {selectedActivity && !editMode && (
          <ActivityDetails
            activity={selectedActivity}
            setEditMode={setEditMode}
            setSelectedActivity={setSelectedActivity}
          />
        )}
        {editMode && (
          <ActivityForm activity={selectedActivity!} setEditMode={setEditMode} createActivity={createActivity} editActivity={editActivity} />
        )}
      </Grid.Column>
    </Grid>
  );
};
