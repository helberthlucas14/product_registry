#!/bin/bash

# Verifica se o tópico já foi criado
if aws --endpoint-url=http://localstack:4566 sns list-topics | grep -q "catalog-emit"; then
  echo "O tópico 'catalog-emit' já existe. Ignorando a execução dos comandos de criação."
  exit 0  # Sai do script com status de sucesso
fi

# Se o tópico não existir, execute os comandos de criação
aws --endpoint-url=http://localstack:4566 s3api create-bucket --bucket bucket-catalog
aws --endpoint-url=http://localstack:4566 sns create-topic --name catalog-emit
aws --endpoint-url=http://localstack:4566 sqs create-queue --queue-name queue-products
aws --endpoint-url=http://localstack:4566 sns subscribe --topic-arn arn:aws:sns:us-east-1:000000000000:catalog-emit --protocol sqs --notification-endpoint arn:aws:sqs:us-east-1:000000000000:queue-products
tail -f /dev/null