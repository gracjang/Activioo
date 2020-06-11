import React, { useContext } from "react";
import { Card, Button } from "semantic-ui-react";
import { Image } from "semantic-ui-react";
import { IActivity } from "./../../app/models/activity";
import ActivityStore from "../../app/stores/ActivityStore";
import { observer } from "mobx-react-lite";

const ActivityDetails: React.FC = () => {
  const activityStore = useContext(ActivityStore);
  const {
    selectedActivity: activity,
    openEditForm,
    cancelSelectedActivity,
  } = activityStore;
  
  return (
    <Card fluid>
      <Image
        src={`/assets/categoryImages/${activity!.category}.jpg`}
        wrapped
        ui={false}
      />
      <Card.Content>
        <Card.Header>{activity!.title}</Card.Header>
        <Card.Meta>
          <span>{activity!.date}</span>
        </Card.Meta>
        <Card.Description>{activity!.description}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group widths={2} size="large">
          <Button
            onClick={() => openEditForm(activity!.id)}
            icon="edit"
            color="blue"
            content="Edit"
          />
          <Button.Or />
          <Button
            onClick={cancelSelectedActivity}
            icon="cancel"
            color="red"
            content="Cancel"
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
};

export default observer(ActivityDetails);
