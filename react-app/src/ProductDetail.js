import React from "react";
import { useQuery, gql } from "@apollo/client";
import {
  List,
  ListItem,
  ListItemText,
  ListItemAvatar,
  Box,
} from "@mui/material";
import NumbersIcon from "@mui/icons-material/Numbers";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";
import CategoryIcon from "@mui/icons-material/Category";

const GET_PRODUCT = gql`
  query GetProduct($id: ID!) {
    product(id: $id) {
      id
      sku
      name
      description
      unitMsrp
      productAttributes {
        productAttributeType {
          code
          name
        }
        value
      }
    }
  }
`;

function ProductDetail({ node }) {
  const { loading, error, data } = useQuery(GET_PRODUCT, {
    variables: { id: node.id },
  });

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :</p>;

  const product = data.product;

  return (
    <Box marginLeft={7}>
      <List disablePadding>
        <ListItem>
          <ListItemAvatar>
            <NumbersIcon />
          </ListItemAvatar>
          <ListItemText primary="SKU" secondary={product.sku}></ListItemText>
        </ListItem>
        <ListItem>
          <ListItemAvatar>
            <AttachMoneyIcon />
          </ListItemAvatar>
          <ListItemText
            primary="Unit MSRP"
            secondary={product.unitMsrp}
          ></ListItemText>
        </ListItem>
        {product.productAttributes.map((attr, index) => (
          <ListItem key={index}>
            <ListItemAvatar>
              <CategoryIcon />
            </ListItemAvatar>
            <ListItemText
              primary={attr.productAttributeType.name}
              secondary={attr.value}
            ></ListItemText>
          </ListItem>
        ))}
      </List>
    </Box>
  );
}

export default ProductDetail;
