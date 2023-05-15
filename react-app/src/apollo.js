import { ApolloClient, InMemoryCache } from '@apollo/client';

const client = new ApolloClient({
  uri: 'http://localhost:5009/graphql', // replace with your GraphQL server URI
  cache: new InMemoryCache()
});

export default client;