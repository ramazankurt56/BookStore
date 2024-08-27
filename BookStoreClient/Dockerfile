# Stage 1: Build the application
FROM node:18.13.0 AS build


# Set working directory
WORKDIR /app


COPY ["./BookStoreClient/package*.json" ,"./"]


RUN npm install --force


COPY ["./BookStoreClient/" ,"./"]




# Build the Vite application for production
RUN npm run build


# Stage 2: Serve the application
FROM nginx:alpine


# Copy the build files from the build stage
COPY --from=build /app/dist/new-book-store/browser/ /usr/share/nginx/html


# Copy custom Nginx configuration file if you have one
COPY --from=build /app/nginx.conf /etc/nginx/nginx.conf


# Expose port 80
EXPOSE 80


# Start Nginx server
CMD ["nginx", "-g", "daemon off;"]
