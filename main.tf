resource "aws_s3_bucket" "example" {
  bucket = "my-tf-test-bucket-goof-dotnet"
  acl    = "public-read"

  versioning {
    enabled = false
  }

  logging {
    target_bucket = "my-logging-bucket-goof-dotnet"
    target_prefix = "log/"
  }
}

resource "aws_instance" "example" {
  ami           = "ami-0c55b159cbfafe1f0" # An old Amazon Linux 2 AMI
  instance_type = "t2.micro"

  # Unencrypted root block device
  root_block_device {
    encrypted = false
  }

  # Security group allowing unrestricted ingress
  vpc_security_group_ids = [aws_security_group.unrestricted.id]
}

resource "aws_security_group" "unrestricted" {
  name        = "unrestricted-access"
  description = "Allow all inbound traffic"

  ingress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}
