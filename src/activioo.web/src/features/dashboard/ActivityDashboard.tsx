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
}

export const ActivityDashboard: React.FC<IProps> = ({
  activities,
  selectActivity,
  selectedActivity,
  editMode,
  setEditMode
}) => {
  return (
    <Grid>
      <GridColumn width={10}>
        <ActivityList activities={activities} selectActivity={selectActivity} />
      </GridColumn>
      <Grid.Column width={6}>
        {selectedActivity && !editMode && (
          <ActivityDetails activity={selectedActivity}  setEditMode={setEditMode}/>
        )}
        {editMode && <ActivityForm />}
      </Grid.Column>
    </Grid>
  );
};
